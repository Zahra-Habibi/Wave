// start of add and remove navigation active class
const activePage = window.location.pathname;
const navLinks = document.querySelectorAll('nav a').
forEach(link =>{
    if (link.href.includes(`${activePage}`)){
    link.classList.add('home');
  }
});
// end of add and remove navigation active class


// start of dark theme
function darkApplier(){
  var SetTheme = document.body;
  SetTheme.classList.toggle("dark-theme");
  var theme;

  if(SetTheme.classList.contains("dark-theme")){
    theme="DARK";
  }
  else{
    theme="LIGHT"
  }

  localStorage.setItem("pageTheme", JSON.stringify(theme));
}

let GetTheme = JSON.parse(localStorage.getItem("pageTheme"));
if(GetTheme === "DARK"){
  document.body.classList="dark-theme";
}
// end of dark mode 

//Start TO Top link codes
const toTop= document.querySelector(".to-top");
window.addEventListener("scroll",()=>{
    if(window.pageYOffset > 100){
        toTop.classList.add("active");
    }
    else{
        toTop.classList.remove("active");
    }
});
//End of TO Top link codes


//Start Socail media liks
const facebookBtn = document.querySelector(".facebook-btn");
const linkedinBtn = document.querySelector(".linkedin-btn");
const whatsappBtn = document.querySelector(".whatsapp-btn");
//footer socail links
const instagramBtn= document.querySelector(".Instagram-btn-f");
const twitterBtn = document.querySelector(".Twitter-btn-f");

function init(){
    let postUrl = document.location.href;
    let postTitle=encodeURI("Hi everyone, Please check this out: ");

    facebookBtn.setAttribute("href",`https://www.facebook.com/sharer.php?u=${postUrl}&title=${postTitle}`);
    linkedinBtn.setAttribute("href",`https://www.linkedin.com/sharerArticle?url=${postUrl}`);
    whatsappBtn.setAttribute("href",`https://wa.me/?text=${postTitle} ${postUrl}`);
    instagramBtn.setAttribute("href",'https://www.instagram.com/');
    twitterBtn.setAttribute("href",'https://twitter.com/share?url=[post-url]&text=[post-title]&via=[via]&hashtags=[hashtags]');
}
init();
// End of socail media links

// Start of swiper
var swiper = new Swiper(".mySwiper", {
effect: "coverflow",
grabCursor: true,
centeredSlides: true,
slidesPerView: "auto",
coverflowEffect: {
  rotate: 30,
  stretch: 0,
  depth: 700,
  modifier: 3,
  slideShadows: true,
},
autoplay: {
  delay: 2500,
  disableOnInteraction: false,
},
pagination: {
  el: ".swiper-pagination",
},
});
// End of swiper



