using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using scannerFakeBackend.Models;
using scannerFakeBackend.Models.Dto;
using scannerFakeBackend.Repositories;

namespace scannerFakeBackend;

public static class Endpoints
{
    public static WebApplication SetEndPoints(this WebApplication app)
    {
        //---- get all
        app.MapGet("/workflowsettings", async (IWorkflowSettingsRepository repository) =>
        {
            var result = await repository.GetWorkflowSettingsAsync();
            return result is null ? Results.NotFound() : Results.Ok(result);

        })
        .WithName("GetWorkflowSettings")
        .WithOpenApi();

        //---- update one
        app.MapPut("/workflowsettings", async (IWorkflowSettingsRepository repository, WorkflowSettingsDto settings) =>
        {
            try
            {
                var result = await repository.UpdateWorkflowSettingsAsync(settings.Id, settings);
                if (result)
                {
                    return Results.Ok();
                }
                return Results.NotFound();
                
            }
            catch (Exception)
            {
                Console.WriteLine("Error updating workflow settings");
            }
            return Results.NotFound();

        })
        .WithName("UpdateWorkflowSettings")
        .WithOpenApi();

        //---- get one
        app.MapGet("/workflowsettings/{id}", async (IWorkflowSettingsRepository repository, string id) =>
        {
            var result = await repository.GetWorkflowSettingsAsync(id);
            return result is null ? Results.NotFound() : Results.Ok(result);

        })
        .WithName("GetWorkflowSettingsById")
        .WithOpenApi();

        //---- create one
        app.MapPost("/workflowsettings", async (IWorkflowSettingsRepository repository, WorkflowSettingsDto settings) =>
        {
            try
            {
                await repository.CreateWorkflowSettingsAsync(settings);
                return Results.Ok();
                
            }
            catch (Exception)
            {
                Console.WriteLine("Error creating workflow settings");
            }
            return Results.NotFound();

        })
        .WithName("CreateWorkflowSettings")
        .WithOpenApi();

        //---- delete one
        app.MapDelete("/workflowsettings/{id}", async (IWorkflowSettingsRepository repository, string id) =>
        {
            try
            {
                var result = await repository.DeleteWorkflowSettingsAsync(id);
                if (result)
                {
                    return Results.Ok();
                }
                return Results.NotFound();
                
            }
            catch (Exception)
            {
                Console.WriteLine("Error deleting workflow settings");
            }
            return Results.NotFound();

        })
        .WithName("DeleteWorkflowSettings")
        .WithOpenApi();


        app.MapPost("/workflowsettings/enable", async (IWorkflowSettingsRepository repository, EnableWorkflowDto enableWorkflow) =>
        {
            try
            {
                var result = await repository.EnableWorkflowAsync(enableWorkflow.Id, enableWorkflow.Enable);
                if (result)
                {
                    return Results.Ok();
                }
                return Results.NotFound();
                
            }
            catch (Exception)
            {
                Console.WriteLine("Error enabling workflow");
            }
            return Results.NotFound();

        })
        .WithName("EnableWorkflow")
        .WithOpenApi();
        
        return app;
    }
}