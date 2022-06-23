//Todos os lanches do cardapio
const sandwish = [
    {
        name: "Claudinho Simples",
        image: "./assets/img/claudinho_simples.jpg",
        desc: `Um delicioso lanche simples. Pão com gergelim tostado na hora, mostarda artesanal fresquinha, cebola fresca crocante, hamburger de 120g com carne 100% bovina, duas crocantes e deliciosas fatias de bacon, picles, katchup e um saboroso queijo cheddar`
    },

    {
        name: "Egg Claudinho",
        image: "./assets/img/egg_claudinho.jpg",
        desc: "Um GIGANTE COLOSSAL!! Pão com gergelim artesanal feito no dia, cebola roxa, molho egg claudinho, bacon, hamburger 160g e um ovo frito com a gema na consistência de sua escolha !!"
    },

    {
        name: "Claudinho Vegano",
        image: "./assets/img/claudinho_vegano.jpg",
        desc: "Uma opção vegana!! Pão artesanal sem leite e sem ovo, rúcula, hamburger de soja 140g, duas delicosas fatias de tofu, cebola roxa e duas fatias de tomate fresco"
    },

    {
        name: "Claudinho Bacon",
        image: "./assets/img/claudinho_bacon.jpg",
        desc: "O chefe da casa !! Pão com gergelim, duas folhas de alface crespa, hamburger 140g 100% bovino, cebola fresca, pimentão frito, picles, bacon e uma fatia de queijo cheddar."
    },

    {
        name: "Claudinho Chicken",
        image: './assets/img/claudinho_frango.jpg',
        desc: "Um delicioso lanche de frango !!  Pão artesanal,  maionese fresquinha, cebola roxa, alface crespa, duas rodelas de tomate e uma deliciosa fatia de queijo."
    },

    {
        name: "Mega Claudinho",
        image: './assets/img/mega_claudinho.jpg',
        desc: "Mega Claudinho !! Este lanche é especial.. Vai tudo o que tem na cozinha em cima de um pão gigante e colocado no prato."
    }

]
//Array de containers
const container = [];
const title = [];
const burgerImg = [];
const description = [];

const cardapio = document.querySelector("#menu-items"); //grid

//cria item do menu
const createElements = () => {
    //Titulo, imagem e descrição
    for(let i = 0; i < sandwish.length; i++)
    {
        container.push(document.createElement("article"));
        title.push(document.createElement("h3"));
        burgerImg.push(document.createElement("img"));
        description.push(document.createElement("p"));
    }
    

    
}
//Coloca os valores
const addValues = () => {
    for(let i = 0; i < sandwish.length; i++)
    {
        container[i].classList.add("lanche-container","lanche-grid", "main-content");
        title[i].textContent = `${sandwish[i].name}`;
        burgerImg[i].src = `${sandwish[i].image}`;
        description[i].innerHTML = `${sandwish[i].desc}`;
    }
}

const createContainer = () => {
    for(let i = 0; i < sandwish.length; i++)
    {
        container[i].appendChild(title[i]);
        container[i].appendChild(burgerImg[i]);
        container[i].appendChild(description[i]);
        console.log(container[i]);
    }
}

const addContainer = () => {
    for(let i=0; i < sandwish.length; i++)
        cardapio.appendChild(container[i]);
}

createElements();
addValues();
createContainer();
addContainer();




