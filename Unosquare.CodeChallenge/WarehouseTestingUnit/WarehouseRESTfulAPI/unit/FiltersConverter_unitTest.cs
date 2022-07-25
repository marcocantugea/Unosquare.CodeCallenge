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
        public void test_convertToLinqExpression_getLinqExpressionFromString()
        {
            Func<Product, bool> expression = FiltersConverter.convertToLinqExpression(@"prod=>prod.name.ToLower().Contains(""world"")");
            Assert.IsAssignableFrom<Func<Product, bool>>(expression);
        }

        [Fact]
        public void test_getLinqExpresssion_getvalidexpresssion()
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
        public void test_getLinqExpresssion_getvalidexpresssionContains()
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
        public void test_getLinqExpresssion_getvalidexpresssionNumeric()
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
        public void test_getLinqExpresssion_getvalidexpresssionNumericAgeResctition()
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
        public void test_convetLinqExpression_getLinqExpression()
        {
            ProductFilterRequestModel model = new ProductFilterRequestModel();
            model.field = "ageRestriction";
            model.value = "30";
            model.typeField = (int)typeFields.NUMERIC;
            model.whereOperator = ">=";

            Assert.IsAssignableFrom<Func<Product, bool>>(FiltersConverter.convetLinqExpression(model));
        }
    }
}
