'use strict'

var seconds = 0;
var is_counting = false;
var minutes = 0;

function temporizador() {
    is_counting = -is_counting
    let temp
    if (is_counting){
        temp = setInterval(() => {
    
            seconds++;
            if (seconds === 60) {
                minutes++
            }
            console.log(`${minutes < 10? '0' + minutes : minutes}:${seconds < 10? '0' + seconds : seconds }`); 
        },1000)
    } else {
        clearInterval(temp)
    }
}


let initbtn = document.getElementById("inicio");
initbtn.addEventListener("click", temporizador())

let resetbtn = document.getElementById("reset");
resetbtn.addEventListener("click", () => {
    is_counting = false;
    seconds = 0;
    minutes = 0;
})