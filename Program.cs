using FluentValidation.Results;
using FluentValidationExample.Models;
using FluentValidationExample.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentValidationExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var product = FillProductReady();

            var resultValidator = ValidateProduct(product);

            if (!resultValidator.IsValid)
            {
                Console.WriteLine("The following errors ocurred: ");
                resultValidator.Errors.ToList().ForEach(x => PrintErrorMessages(x.ErrorMessage));
            }
        }

        static Product FillProductReady()
        {
            var item = new Item(0, null, null, null, 0);
            var listItem = new List<Item>();
            listItem.Add(item);
            return new Product(listItem);
        }

        static ValidationResult ValidateProduct(Product product) =>
            new ProductValidator().Validate(product);

        static void PrintErrorMessages(string errorMessage) =>
            Console.WriteLine($"* {errorMessage}");
    }
}