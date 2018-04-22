$(document).ready(function () {
 //memulink
    var url = window.location;
    // Will only work if string in href matches with location
    $('ul.main-link a[href="' + url + '"]').parent().addClass('active');

    // Will also work for relative and absolute hrefs
    $('ul.main-link a').filter(function () {
        return this.href == url;
    }).parent().addClass('active').parent().parent().addClass('active');
    
    /** slide show **/
    var totalItems = $('.item').length;
    var currentIndex = $('div.item.active').index() + 1;
    $('.slide-num').html('' + currentIndex + '/' + totalItems + '');

    $('#slideshow').carousel({
        interval: 4000
    })

    $('#slideshow').on('slid.bs.carousel', function () {
        currentIndex = $('div.item.active').index() + 1;
        $('.slide-num').html('' + currentIndex + '/' + totalItems + '');
    });

    $('.owl-carousel').owlCarousel({
        autoplay: true,
        rewind: true,
        navText: [],
        loop: true,
        margin: 10,
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
                nav: true
            },
            400: {
                items: 2,
                nav: false
            },
            550: {
                items: 3,
                nav: false
            },
            700: {
                items: 4,
                nav: false
            },
            1000: {
                items: 5,
                nav: true,
                loop: false
            }
        }
    })

    /* smooth scroll */
    // Select all links with hashes
    $('a[href*="/"]')
      // Remove links that don't actually link to anything
      //.not('[href="#"]')
      //.not('[href="#0"]')
      .click(function (event) {
          // On-page links
          if (
            location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '')
            &&
            location.hostname == this.hostname
          ) {
              // Figure out element to scroll to
              var target = $(this);
              target = target.length ? target : $('[name=' + this.slice() + ']');
              // Does a scroll target exist?
              if (target.length) {
                  // Callback after animation
                  // Must change focus!
                  var $target = $(target);
                  //$target.focus();
                  if ($target.is(":focus")) { // Checking if the target was focused
                      return false;
                  } else {
                      $target.attr('tabindex', '-1'); // Adding tabindex for elements not focusable
                      $target.focus(); // Set focus again
                  };
                  // Only prevent default if animation is actually gonna happen
                 // event.preventDefault();
                  //$('html, body').animate({
                  //    scrollTop: target.offset().top - 140
                  //}, 1000, function () {

                  //});
              }
          }
      });
    /** page min-height **/
    var pageheight = $(window).height() - $('.footer').height();
    $(".page-content").css("min-height", pageheight);



});