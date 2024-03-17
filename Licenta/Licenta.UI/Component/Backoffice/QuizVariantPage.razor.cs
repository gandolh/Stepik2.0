﻿using Licenta.SDK.Models.Dtos;
using Licenta.UI.Component.Backoffice.Layout;
using Licenta.UI.Data;
using Microsoft.JSInterop;

namespace Licenta.UI.Component.Backoffice
{
    public partial class QuizVariantPage : BaseCrudPage
    {
        public QuizVariantDto NewDto { get; set; } = new QuizVariantDto();


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadDatatable();

            }

            await base.OnAfterRenderAsync(firstRender);
        }

        protected override async Task HandleRemove(int selectedId)
        {
            await httpLicentaClient.DeleteQuizVariant(selectedId);
            await LoadDatatable();
        }

        private async Task HandleCreate()
        {
            await httpLicentaClient.CreateQuizVariant(NewDto);
            await LoadDatatable();
        }

        private async Task LoadDatatable()
        {
            var elts = await httpLicentaClient.GetFullQuizVariants();
            DataTableJson json = new DataTableJson();
            json.ImportOverride(elts);
            var dotnetRef = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("MaterializeInitializer.InitDataTable", EltId, json, _modalRemoveId, ModalUpdateId, dotnetRef);
        }

        private void HandleUpdate()
        {

        }

        protected override Task HandleSelectedIdChanged(int selectedId)
        {
            throw new NotImplementedException();
        }
    }
}
