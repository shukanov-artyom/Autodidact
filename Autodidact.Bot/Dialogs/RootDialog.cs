using System;
using System.Threading.Tasks;
using Bot.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;

namespace Bot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceivedAsync);
        }

        protected virtual async Task MessageReceivedAsync(
            IDialogContext context,
            IAwaitable<IMessageActivity> result)
        {
            var appOperationDialog = FormDialog
                .FromForm(ApplicationOperation.BuildForm);
            context.Call(appOperationDialog, ResumeAfterCallback);
        }

        private async Task ResumeAfterCallback(IDialogContext context,
            IAwaitable<ApplicationOperation> result)
        {
            ApplicationOperation model = await result;
            if (model.OperationType ==
                ApplicationOperationType.ReportConsumedDocument)
            {
                throw new NotImplementedException();
            }
            else if (model.OperationType ==
                     ApplicationOperationType.RetrieveConsumedDocuments)
            {
                throw new NotImplementedException();
            }
        }
    }
}