
# ASP.NET Core Dynamic Page Loading System (AKA Better Pages)

## Overview
The ASP.NET Core Dynamic Page Loading System is a framework designed to streamline the loading of web pages by dynamically loading content into a base page using partial views. This approach allows for faster loading times and reduced data usage, as only the necessary content is fetched from the server.

## Demo

![ezgif com-animated-gif-maker](https://github.com/MattterSteege/BetterPages/assets/78482881/bc0201bc-ae0f-4f22-afd3-21e3e144770a)*

As you can see the left column does not change, nor flicker during the page load (even with the Font Awesome icons). The only thing that changes is the content on the right side of the screen.

*This is a personal project for which I developed this system, but this is just **a** use of the system.

## Features

- **Dynamic Page Loading**: Load only the necessary content of web pages, reducing data transfer and speeding up page load times.
- **Partial View Integration**: Utilize ASP.NET Core's partial view feature to modularize page content and maintain a centralized framework.
- **Custom JavaScript Handling**: Implement custom JavaScript handling to minify scripts before sending them to the client, optimizing performance.
- **Centralized Framework**: Maintain a consistent base page layout while allowing for flexible content updates.

### Installation
To install the ASP.NET Core Dynamic Page Loading System, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/MattterSteege/BetterPages.git
   ```

2. Navigate to the project directory:

   ```bash
   cd BetterPages
   ```

3. Build the project:

   ```bash
   dotnet build
   ```

4. Run the project:

   ```bash
   dotnet run
   ```

5. Access the application in your web browser at `http://localhost:5000` or `https://localhost:5001`.
## Setup your project

1. Copy the `BetterPages` class library and import it into your project
2. in your `Program.cs` (or `Startup.cs`) these lines of code are added:
```
app.UseBetterPagesMiddleware(); //MAKE SURE THIS IS ADDED!
//and set 
app.MapControllerRoute(name: "default", pattern: "{controller=BetterPages}/{action=Index}/{id?}"); //Has to be this!
```
3. In any controller, add the `[BetterPages]` attribute and turn `return View()` into `return PartialView()`



## Setup your view(.cshtml)'s

### _Layout.cshtml

Copy over this snippet and change it to you likings:

```
<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <title>BetterPages</title>
    <meta name="viewport" content="user-scalable=no, width=device-width, initial-scale=1, maximum-scale=1">
</head>
<body onload="InitBetterPages()">



<main id="main">
    @RenderBody()
</main>

</body>
</html>
```

The only things that you need to keep are:
1. `<!DOCTYPE html>` at the top!
2. `onload="InitBetterPages()"`
3. `<main id="main">@RenderBody()</main>`

These are all used by the system, the rest can be changed to your likings. The main element also doesn't need to be directly inside the body tag, it can be anywhere else.

You also need to keep in mind that the size of the main element is the bounding box of all your partialViews!

### anyOtherView.cshtml

The example project has Privacy.cshtml, what you can do is the following: at the start of view you can add <link> tags for stylesheets, and <script src=""> tags for external scripts.
You can also add <script>[JS code inside]</script> tags, these need to be placed at the end of your file.

Between those 2 you can add any html you like, so easy.

And because of current system it is possible to minify your javascript, using the <script minimize>, if you want to use this, you need to add `@addTagHelper *, BetterPages` to your _ViewImports.cshtml file
## Contributing

Contributions are welcome! If you'd like to contribute to the ASP.NET Core Dynamic Page Loading System, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them with descriptive commit messages.
4. Push your changes to your fork.
5. Submit a pull request to the main repository.

## License

[MIT](https://choosealicense.com/licenses/mit/)

