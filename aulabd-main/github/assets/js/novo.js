const MaiorIdade = function (idade){
    if(idade >= 18){
        return "maior";
    }
    else{
        return "menor"
    }
}
console.log(MaiorIdade());