using System;
using Microsoft.Bot.Builder.FormFlow;

namespace Bot.Models
{
    [Serializable]
    public class ApplicationOperation
    {
        public ApplicationOperationType OperationType
        {
            get;
            set;
        }

        public static IForm<ApplicationOperation> BuildForm()
        {
            return new FormBuilder<ApplicationOperation>()
                .Message("Hello!")
                .Field(nameof(OperationType), "Please select operation. {||}")
                .Message("Thank you.")
                .Build();
        }
    }
}