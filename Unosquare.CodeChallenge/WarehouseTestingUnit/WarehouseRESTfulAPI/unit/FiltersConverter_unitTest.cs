using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Models;
using WarehouseRESTfulAPI.Helpers;
using WarehouseRESTfulAPI.RequestModels;

namespace WarehouseTestingUnit.WarehouseRESTfulAPI.unit
{
    public class FiltersConverter_unitTest
    {
        [Fact]
        public void ConvertToLinqExpression_GetLinqExpressionFromString()
        {
            Func<Product, bool> expression = FiltersConverter.convertToLinqExpression(@"prod=>prod.name.ToLower().Contains(""world"")");
            Assert.IsAssignableFrom<Func<Product, bool>>(expression);
        }

        [Fact]
        public void GetLinqExpresssion_GetValidExpresssion()
        {
            //string linqExp = @"prod=>prod.name.ToLower().Contains(""world"")";
            string linqExp = @"prod=>prod.name==""world""";
            ProductFilterRequestModel model = new ProductFilterRequestModel();
            model.field = "name";
            model.value = "world";
            model.typeField = (int)typeFields.STRING;
            model.whereOperator = "==";
            string linqExpFun = FiltersConverter.getLinqExpression(model);

            Assert.Equal(linqExpFun, linqExp);
            Assert.IsAssignableFrom<Func<Product, bool>>(FiltersConverter.convertToLinqExpression(linqExpFun));
        }

        [Fact]
        public void GetLinqExpresssion_GetValidExpresssionContains()
        {
            string linqExp = @"prod=>prod.name.ToLower().Contains(""world"")";
            //string linqExp = @"prod=>prod.name=='world'";
            ProductFilterRequestModel model = new ProductFilterRequestModel();
            model.field = "name";
            model.value = "world";
            model.typeField = (int)typeFields.STRING;
            model.whereOperator = "contains";
            string linqExpFun = FiltersConverter.getLinqExpression(model);

            Assert.Equal(linqExpFun, linqExp);
            Assert.IsAssignableFrom<Func<Product, bool>>(FiltersConverter.convertToLinqExpression(linqExpFun));
        }

        [Fact]
        public void GetLinqExpresssion_GetValidExpressionWithNumericType()
        {
            string linqExp = @"prod=>prod.price<10";
            //string linqExp = @"prod=>prod.name=='world'";
            ProductFilterRequestModel model = new ProductFilterRequestModel();
            model.field = "price";
            model.value = "10";
            model.typeField = (int)typeFields.DECIMAL;
            model.whereOperator = "<";
            string linqExpFun = FiltersConverter.getLinqExpression(model);

            Assert.Equal(linqExpFun, linqExp);
            Assert.IsAssignableFrom<Func<Product, bool>>(FiltersConverter.convertToLinqExpression(linqExpFun));
        }


        [Fact]
        public void GetLinqExpresssion_GetValidExpressionWithAgeResctition()
        {
            string linqExp = @"prod=>prod.ageRestriction>=30";
            ProductFilterRequestModel model = new ProductFilterRequestModel();
            model.field = "ageRestriction";
            model.value = "30";
            model.typeField = (int)typeFields.NUMERIC;
            model.whereOperator = ">=";
            string linqExpFun = FiltersConverter.getLinqExpression(model);

            Assert.Equal(linqExpFun, linqExp);
            Assert.IsAssignableFrom<Func<Product, bool>>(FiltersConverter.convertToLinqExpression(linqExpFun));
        }

        [Fact]
        public void ConvetLinqExpression_GetLinqExpression()
        {
            ProductFilterRequestModel model = new ProductFilterRequestModel();
            model.field = "ageRestriction";
            model.value = "30";
            model.typeField = (int)typeFields.NUMERIC;
            model.whereOperator = ">=";

            Assert.IsAssignableFrom<Func<Product, bool>>(FiltersConverter.convetLinqExpression(model));
        }

        [Fact]
        public void GetLinqExpresssion_GetValidExpressionWithAnds()
        {
            string linqExp = @"prod=>( prod.ageRestriction>=30 && prod.name.ToLower().Contains(""world""))";
            ProductFilterRequestModel model1 = new ProductFilterRequestModel();
            model1.field = "ageRestriction";
            model1.value = "30";
            model1.typeField = (int)typeFields.NUMERIC;
            model1.whereOperator = ">=";

            ProductFilterRequestModel model3 = new ProductFilterRequestModel();
            model3.field = "name";
            model3.value = "world";
            model3.typeField = (int)typeFields.STRING;
            model3.whereOperator = "contains";

            ProductFilterRequestModel[] filters =new ProductFilterRequestModel[] { model1, model3 };

            string linqExpFun = FiltersConverter.getLinqExpressions(filters);

            Assert.Equal(linqExpFun, linqExp);
            Assert.IsAssignableFrom<Func<Product, bool>>(FiltersConverter.convertToLinqExpression(linqExpFun));
        }

        [Fact]
        public void GetLinqExpresssion_GetValidExpressionWithNoAnds()
        {
            string linqExp = @"prod=> prod.ageRestriction>=30";
            ProductFilterRequestModel model1 = new ProductFilterRequestModel();
            model1.field = "ageRestriction";
            model1.value = "30";
            model1.typeField = (int)typeFields.NUMERIC;
            model1.whereOperator = ">=";

            ProductFilterRequestModel[] filters = new ProductFilterRequestModel[] { model1 };

            string linqExpFun = FiltersConverter.getLinqExpressions(filters);

            Assert.Equal(linqExpFun, linqExp);
            Assert.IsAssignableFrom<Func<Product, bool>>(FiltersConverter.convertToLinqExpression(linqExpFun));
        }
    }
}
