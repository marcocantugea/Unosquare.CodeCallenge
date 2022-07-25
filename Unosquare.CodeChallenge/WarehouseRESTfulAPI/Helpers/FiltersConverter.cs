using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using WarehouseModels.Interfaces;
using WarehouseModels.Models;
using WarehouseRESTfulAPI.RequestModels;

namespace WarehouseRESTfulAPI.Helpers
{
    public class FiltersConverter
    {

        public static  Func<IProduct, bool> convertToLinqExpression(string expression)
        {
            var options = ScriptOptions.Default.AddReferences(typeof(Product).Assembly);

            Func<IProduct, bool> linqExpression = CSharpScript.EvaluateAsync<Func<IProduct, bool>>(expression, options).Result;
            return linqExpression;
        }

        public static string getLinqExpression(ProductFilterRequestModel model)
        {
            List<string> stringOperators = new List<string>() { "==","contains" };
            List<string> numericOperators = new List<string>() { "==", "!=",">","<",">=","<=" };

            string linqExp = @"";

            if(model.typeField == (int)typeFields.NUMERIC || model.typeField == (int)typeFields.DECIMAL)
            {
                //revisamos los operadores permitidos
                if (!numericOperators.Contains(model.whereOperator)) throw new Exception($"operator {model.whereOperator} is not valid for a numeric field");
                //realizamos expression linq
                linqExp = @"prod=>prod." + model.field+ model.whereOperator +  model.value;
                return linqExp;
            }

            if (model.typeField == (int)typeFields.BOOLEAN || model.typeField==10)
            {
                //revisamos los operadores permitidos
                if (model.whereOperator!="==") throw new Exception($"operator {model.whereOperator} is not valid for a boolean field");
                //realizamos expression linq
                linqExp = @"prod=>prod." + model.field + model.whereOperator + model.value;
                return linqExp;
            }
            //revisamos los operadores permitidos
            if (stringOperators.Where(item => item==model.whereOperator)==null) throw new Exception($"operator {model.whereOperator} is not valid for a string field");

            //realizamos expression linq
            linqExp = @"prod=>prod." + model.field;
            if (model.whereOperator != "==") linqExp = linqExp + ".ToLower().Contains(\"" + model.value.ToLower() + "\")";
            if (model.whereOperator == "==") linqExp = linqExp + "==\"" + model.value + "\"";
            //if (model.whereOperator == "contains") 

            return linqExp;
        }

        public static Func<IProduct, bool> convetLinqExpression(ProductFilterRequestModel model)
        {
            string stringLinqExpression= FiltersConverter.getLinqExpression(model);
            try
            {
                return FiltersConverter.convertToLinqExpression(stringLinqExpression);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
