$(function() {
    $(window).on("load", function() {
      $('#preloader').fadeOut('slow', function() {
        $(this).remove();
      });
    }, 500);
  });