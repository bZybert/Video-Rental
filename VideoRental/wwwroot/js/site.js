// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var btn = document.querySelector('#customers .js-delete');
console.log(btn);

btn.addEventListener("click", () => {
    console.log("it works");
});
