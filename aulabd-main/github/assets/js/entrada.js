const aparece = document.querySelectorAll(".some");

for(let i = 0; i < aparece.length; i++){
    window.addEventListener("scroll", () =>{
        aparece[i].classList.remove("some");
        aparece[i].classList.add("aparece");
    })
    
}

