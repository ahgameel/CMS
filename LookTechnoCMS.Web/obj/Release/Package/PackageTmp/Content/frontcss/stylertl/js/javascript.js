$( document ).ready(function() {
    $('.main-link li > a').click(function() {
        $('li').removeClass();
        $(this).parent().addClass('active');
    });

/** slide show **/
    var totalItems = $('.item').length;
    var currentIndex = $('div.active').index() + 1;
    $('.slide-num').html(''+currentIndex+'/'+totalItems+'');

    $('#slideshow').carousel({
        interval:4000
    })

   $('#slideshow').on('slid.bs.carousel', function() {
        currentIndex = $('div.active').index() + 1;
        $('.slide-num').html(''+currentIndex+'/'+totalItems+'');
    });

    $('.owl-carousel').owlCarousel({
    autoplay:true,   
    rewind:true,
    navText: [],
    loop:true,
    margin:10,
    responsiveClass:true,
    responsive:{
        0:{
            items:1,
            nav:true
        },
        400:{
            items:2,
            nav:false
        },
        550:{
            items:3,
            nav:false
        },
        700:{
            items:4,
            nav:false
        },
        1000:{
            items:5,
            nav:true,
            loop:false
        }
    }
    })

/* smooth scroll */
// Select all links with hashes
$('a[href*="#"]')
  // Remove links that don't actually link to anything
  .not('[href="#"]')
  .not('[href="#0"]')
  .click(function(event) {
    // On-page links
    if (
      location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') 
      && 
      location.hostname == this.hostname
    ) {
      // Figure out element to scroll to
      var target = $(this.hash);
      target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
      // Does a scroll target exist?
      if (target.length) {
        // Only prevent default if animation is actually gonna happen
        event.preventDefault();
        $('html, body').animate({
          scrollTop: target.offset().top - 140
        }, 1000, function() {
          // Callback after animation
          // Must change focus!
          var $target = $(target);
          $target.focus();
          if ($target.is(":focus")) { // Checking if the target was focused
            return false;
          } else {
            $target.attr('tabindex','-1'); // Adding tabindex for elements not focusable
            $target.focus(); // Set focus again
          };
        });
      }
    }
  });
  /** page min-height **/
    var pageheight = $(window).height() - $('.footer').height();
    $(".page-content").css("min-height", pageheight);
    
  

});