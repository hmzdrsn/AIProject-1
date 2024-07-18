using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application.Common.Models.BaseModels
{
    public class DataResponse<T>
    {
        public string? Message { get; set; }
        public string? Status { get; set; }
        public T? Data { get; set; }
        public object? ErrorList { get; set; }

    }

    /*
     
     "errorList": [ ===> AUTO MAP KULLANICAZ.
    {
      "propertyName": "EnglishDegreeId",
      "errorMessage": "degree yok amk",
      "attemptedValue": "31",
      "customState": null,
      "severity": 0,
      "errorCode": "PredicateValidator",
      "formattedMessagePlaceholderValues": {
        "PropertyName": "English Degree Id",
        "PropertyValue": "31",
        "PropertyPath": "EnglishDegreeId"
      }
    }
  ]
     */


}
