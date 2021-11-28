let socialNav = document.getElementById('social-navbar')
let fullNav = document.getElementById('full-nav')
let togglerBtn = document.getElementById('toggler-btn');
let hideNav = document.getElementById('hide-nav');

let navlinks = document.getElementsByClassName('sm-link-click')


 window.addEventListener('mouseup',function(event){
     if(event.target != hideNav && event.target.parentNode != hideNav){
         hideNav.style.display = 'none';
         socialNav.style.display = 'none'
         fullNav.style.backgroundColor = 'transparent'
         if(this.window.innerWidth < 992){
            togglerBtn.style.display = 'block';
         }

     }
 });  

togglerBtn.addEventListener('click',function(event){
    

    togglerBtn.style.display = 'none';
    hideNav.style.display = 'block'
    socialNav.style.display = 'flex'
    fullNav.style.backgroundColor = 'white'

 
    
});  

for (let index = 0; index < navlinks.length; index++) {
    navlinks[index].addEventListener('click',function(){
        hideNav.style.display = 'none';
        socialNav.style.display = 'none'
        fullNav.style.backgroundColor = 'transparent'
        togglerBtn.style.display = 'block';
        
    }) 
    
}

$(document).ready(function(){
    $(".owl-carousel").owlCarousel({
        items:1,
    margin:10,
    autoHeight:true,
    loop:true,
    
    });
  });


