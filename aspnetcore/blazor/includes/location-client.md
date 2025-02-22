This guidance applies to:

:::moniker range=">= aspnetcore-8.0"

* Interactive client rendering of a Blazor Web App. The `Program` file is `Program.cs` of the client project (`.Client`). Blazor script start configuration is found in the `App` component (`Components/App.razor`) of the server project.
* A Blazor WebAssembly app. The `Program` file is `Program.cs`. Blazor script start configuration is found in the `wwwroot/index.html` file.

Routable components with an `@page` directive are placed in the `Components/Pages` folder. Non-routable shared components are placed in the `Components` folder.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* The **`Client`** project of a hosted Blazor WebAssembly solution.
* A Blazor WebAssembly app.

Blazor script start configuration is found in the `wwwroot/index.html` file. The `Program` file is `Program.cs`.

:::moniker-end
