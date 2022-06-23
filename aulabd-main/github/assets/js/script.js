const menu = document.querySelector("#menu");
const burger = document.querySelector("#menu-burg"); //itens do menu
const link = document.querySelectorAll("a");

burger.addEventListener("click", () => {
    menu.classList.toggle("open");
})
// Sai do menu quando clica em alguma das opções
for(let i = 0; i < link.length; i++)
{
    link[i].addEventListener("click", () => {
        menu.classList.remove("open");
    })
}
