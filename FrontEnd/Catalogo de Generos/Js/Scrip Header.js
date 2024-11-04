let navlist = document.querySelectorAll(".navList li a");

navlist.forEach(item => {
    let characters = item.textContent.split("");
    item.textContent = "";
    characters.forEach((char, index)=>{
        index += 1;
        let span = document.createElement("span"); 
        let delay = index / 15;

        let charUp = document.createElement("span");
        charUp.textContent = char;
        charUp.style.transitionDelay = `${delay}s`
        charUp.classList.add("up")
        span.append(charUp);

        let charDown = document.createElement("span");
        charDown.textContent = char;
        charDown.style.transitionDelay = `${delay}s`
        charDown.classList.add("down")
        span.append(charDown);

        item.append(span);
    });
});

let list = document.querySelector(".navList");
let menuIcon = document.querySelector(".menuIcon");
menuIcon.addEventListener("click", () => {
    menuIcon.classList.toggle("active");
    list.classList.toggle("activeMenu");
});