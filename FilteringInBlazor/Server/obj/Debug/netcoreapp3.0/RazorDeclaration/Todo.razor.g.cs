#pragma checksum "C:\Mentoring\GitHub\App\FilteringInBlazor\FilteringInBlazor\Server\Todo.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea6d40b8577e0deee67ee4c303c49ecc4f2d4a70"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FilteringInBlazor.Server
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 2 "C:\Mentoring\GitHub\App\FilteringInBlazor\FilteringInBlazor\Server\Todo.razor"
using FilteringInBlazor.Shared.ViewModels;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/todo")]
    public class Todo : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 23 "C:\Mentoring\GitHub\App\FilteringInBlazor\FilteringInBlazor\Server\Todo.razor"
       
    private IList<TodoItem> todos = new List<TodoItem>();
    private string newTodo;
    private bool showCompletedTasks = false;

    protected override async Task OnInitializedAsync()
    {
        todos = await Http.GetJsonAsync<List<TodoItem>>("Todo/Get/"+ showCompletedTasks);
    }

    private void AddTodo()
    {
        if (!string.IsNullOrWhiteSpace(newTodo))
        {
            var newItem = new TodoItem
            {
                Title = newTodo
            };
            Http.PostJsonAsync<TodoItem>("todo", newItem);

            newTodo = string.Empty;

        }
    }

    private void ChangeItem()
    {
        var newItem = new TodoItem
        {
            Title = "kk"
        };
        Http.PostJsonAsync<TodoItem>("todo", newItem);
        
    }


#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591