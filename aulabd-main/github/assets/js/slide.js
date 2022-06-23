
let time = 2000; //Dellay do slide
let currentImg = 0; //imagem atual
const images = document.querySelectorAll("#slider img"); //lista com todas as imagens
const maximg = images.length; //quantidade maxima dei magens


const nextImage  = () => {
    //remove a classe select pra ele resetar a animação quando as imagens acabarem
    images[currentImg].classList.remove("select");
    //vai pra proxima imagem
    currentImg++;

    //se o contador for maior que o maximo de imagens ele volta pra primeira
    if(currentImg >= maximg)
        currentImg = 0;
    //coloca a classe select
    images[currentImg].classList.add("select");
          
}
//inicia a animação em um determinado tempo
const startAnimation = () => {
    images[currentImg].classList.add("select");
    setInterval(nextImage, time);
}


window.addEventListener("load", startAnimation); //Chama a animação quando a pagina é carregada
