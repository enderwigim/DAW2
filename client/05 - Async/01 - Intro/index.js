'use strict'

var seconds = 0;
var is_counting = false;
var minutes = 0;
var temp;

let p = document.getElementById("temp");
function temporizador() {
    is_counting = !is_counting;
    if (is_counting){
        temp = setInterval(() => {
    
            seconds++;
            if (seconds === 60) {
                minutes++
            }
            p.innerHTML = (`${minutes < 10? '0' + minutes : minutes}:${seconds < 10? '0' + seconds : seconds }`); 
        },1000)
    } else {
        clearInterval(temp)
    }
}


let initbtn = document.getElementById("inicio");
initbtn.addEventListener("click", temporizador)

let resetbtn = document.getElementById("reset");
resetbtn.addEventListener("click", () => {
    seconds = 0;
    minutes = 0;
    p.innerHTML = `00:00`
    clearInterval(temp)
})