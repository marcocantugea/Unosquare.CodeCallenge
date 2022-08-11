using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Models;
using WarehouseRESTfulAPI.Helpers;
using WarehouseRESTfulAPI.RequestModels;
using Xunit;

namespace WarehouseTestingUnit.WarehouseRESTfulAPI.unit
{
    public class FiltersConverter_unitTest
    {
        [Theory]
        [InlineData(@"prod=>prod.Name.ToLower().Contains(""world"")")]
        public void ConvertToLinqExpression_GetLinqExpressionFromString(string strExpression)
        {
            Func<Product, bool> expression = FiltersConverter.convertToLinqExpression(strExpression);
            Assert.IsAssignableFrom<Func<Product, bool>>(expression);
        }

        [Theory]
        [InlineData("Name", "world", (int)typeFields.STRING, "==",@"prod=>prod.Name==""world""")]
        [InlineData("Name", "world", (int)typeFields.STRING, "contains", @"prod=>prod.Name.ToLower().Contains(""world"")")]
        [InlineData("Price", "10", (int)typeFields.DECIMAL, "<", @"prod=>prod.Price<10")]
        [InlineData("AgeRestriction", "30", (int)typeFields.NUMERIC, ">=", @"prod=>prod.AgeRestriction>=30")]
        public void GetLinqExpresssion_GetValidExpresssion(string field, string value, int typeField, string whereOperator,string expected)
        {
            ProductFilterRequestModel model = new ProductFilterRequestModel();
            model.field = field;
            model.value = value;
            model.typeField = typeField;
            model.whereOperator = whereOperator;
            string linqExpFun = FiltersConverter.getLinqExpression(model);

            Assert.Equal(linqExpFun, expected);
            Assert.IsAssignableFrom<Func<Product, bool>>(FiltersConverter.convertToLinqExpression(linqExpFun));
        }

        [Fact]
        public void GetLinqExpresssion_GetValidExpressionWithAnds()
        {
            string linqExp = @"prod=>( prod.AgeRestriction>=30 && prod.Name.ToLower().Contains(""world""))";
            ProductFilterRequestModel model1 = new ProductFilterRequestModel();
            model1.field = "AgeRestriction";
            model1.value = "30";
            model1.typeField = (int)typeFields.NUMERIC;
            model1.whereOperator = ">=";

            ProductFilterRequestModel model3 = new ProductFilterRequestModel();
            model3.field = "Name";
            model3.value = "world";
            model3.typeField = (int)typeFields.STRING;
            model3.whereOperator = "contains";

            ProductFilterRequestModel[] filters =new ProductFilterRequestModel[] { model1, model3 };

            string linqExpFun = FiltersConverter.getLinqExpressions(filters);

            Assert.Equal(linqExpFun, linqExp);
            Assert.IsAssignableFrom<Func<Product, bool>>(FiltersConverter.convertToLinqExpression(linqExpFun));
        }

    }
}
