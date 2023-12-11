
var day_2 = new Date("Dec 11, 2023 10:00:00").getTime();
var day_3 = new Date("Dec 11, 2023 10:00:00").getTime();
var day_4 = new Date("Dec 11, 2023 10:00:00").getTime();
var day_5 = new Date("Dec 11, 2023 10:00:00").getTime();
var day_6 = new Date("Dec 11, 2023 10:00:00").getTime();
var day_7 = new Date("Dec 11, 2023 10:00:00").getTime();

var site = {

  successAlert: function (title, message) {
    swal(title, message, "success");
  },
  successAlertAutoClose: function (title, message) {
    swal({
      title: title,
      text: message,
      type: "success",
      timer: 5000,
      showConfirmButton: false
    });
  },
  warningAlertAutoClose: function (title, message) {
    swal({
      title: title,
      text: message,
      type: "warning",
      timer: 5000,
      showConfirmButton: false
    });
  },
  warningAlert: function (title, message) {
    swal({
      title: title,
      text: message,
      type: "warning"
    });
  },

  verifyNextSlide: function () {

    var todayDate = new Date().getTime();

    document.getElementById("data_loader").style.display = "";

    $.ajax({
      url: "/Home/GetSlideIndex",
      type: "post",
      dataType: 'json',
      complete: function (xhr, textStatus) {

        if (xhr.status == 200) {

          switch (xhr.responseText) {
            case "1":
              location.href = "/Home/Game"
              break;
            case "2":
              if (todayDate > day_2) {
                location.href = "/Home/Game"
              }
              else {
                site.warningAlert("2. pálya", "Sikeresen vetted az első akadályt de a 2. pálya még nem nyílt ki ..de hamarosan.");
              }
              break;
            case "3":
              if (todayDate > day_3) {
                location.href = "/Home/Game"
              }
              else {
                site.successAlertAutoClose("3. pálya", "Sikeresen vetted a második akadályt de a 3. pálya még nem nyílt ki ..de hamarosan.");
              }
              break;
            case "4":
              if (todayDate > day_4) {
                location.href = "/Home/Game"
              }
              else {
                site.successAlertAutoClose("4. pálya", "Sikeresen vetted a harmadik akadályt de a 4. pálya még nem nyílt ki ..de hamarosan.");
              }
              break;
            case "5":
              if (todayDate > day_5) {
                location.href = "/Home/Game"
              }
              else {
                site.successAlertAutoClose("5. pálya", "Sikeresen vetted a negyedik akadályt de a 5. pálya még nem nyílt ki ..de hamarosan.");
              }
              break;
            case "6":
              if (todayDate > day_6) {
                location.href = "/Home/Game"
              }
              else {
                site.successAlertAutoClose("6. pálya", "Sikeresen vetted az ötödik akadályt de a 6. pálya még nem nyílt ki ..de hamarosan.");
              }
              break;
            case "7":
              if (todayDate > day_7) {
                location.href = "/Home/Game"
              }
              else {
                site.successAlertAutoClose("7. pálya", "Sikeresen vetted a hatodik akadályt de a 7. pálya még nem nyílt ki ..de hamarosan.");
              }
              break;
            case "8":
              location.href = "/Home/Gift"
              break;
          }

          document.getElementById("data_loader").style.display = "none";

          return false;
        }
        else {
          location.href = "/Home/Error";
          return false;
        }
      }

    });

  },

  verifySlide: function (slide_index) {

    var todayDate = new Date().getTime();

    switch (slide_index) {

      case "1":

        if ($('#name').val() != "34") {
          site.warningAlert("Varázsige", "Sajnos nem nyert. De próbálkozhatsz még :)");
          return;
        }

        //Save slide
        var respons = site.saveIndex(slide_index);

        if (todayDate > day_2) {

          site.successAlertAutoClose("Ügyes :)", "Látod, nem is volt olyan nehéz. A többi nem lesz ilyen könnyű :) Akkor nézzük");
          setTimeout(function () {
            location.href = "/Home/Game"
          }, 6000);

        }
        else {

          site.successAlertAutoClose("Ügyes :)", "Sikeresen vetted az első akadályt de a következő " + slide_index + ". pálya még nem nyílt ki ..de hamarosan!");
          setTimeout(function () {
            location.href = "/Home"
          }, 6000);

        } 

        break;

      case "2":

        if ($('#name').val() != "finnorszag") {
          site.warningAlert("Varázsige", "Sajnos nem nyert. De próbálkozhatsz még :). Használj kisbetüt és ékezet nélkül add meg a választ ");
          return;
        }

        //Save slide
        var respons = site.saveIndex(slide_index);

        if (todayDate > day_3) {

          site.successAlertAutoClose("Ügyes :)", "Nagyon jól nyomod! Akkor nézzük tovább!");
          setTimeout(function () {
            location.href = "/Home/Game"
          }, 6000);

        }
        else {

          site.successAlertAutoClose("Nagyon jól nyomod!", "Sikeresen vetted a második akadályt is de a következő " + slide_index + ". pálya még nem nyílt ki ..de hamarosan!");
          setTimeout(function () {
            location.href = "/Home"
          }, 6000);

        } 

        break;

      case "3":

        if ($('#name').val() != "mary poppins") {
          site.warningAlert("Varázsige", "Sajnos nem nyert. De próbálkozhatsz még :). Használj kisbetüt és ékezet nélkül add meg a választ ");
          return;
        }

        //Save slide
        var respons = site.saveIndex(slide_index);

        if (todayDate > day_4) {

          site.successAlertAutoClose("Cool", "Nagyon jól nyomod! Akkor nézzük tovább!");
          setTimeout(function () {
            location.href = "/Home/Game"
          }, 6000);

        }
        else {

          site.successAlertAutoClose("Cool!", "Sikeresen vetted a harmadik akadályt is de a következő " + slide_index + ". pálya még nem nyílt ki ..de hamarosan!");
          setTimeout(function () {
            location.href = "/Home"
          }, 6000);

        } 

        break;

      case "4":

        if ($('#name').val() != "zagrab") {
          site.warningAlert("Varázsige", "Sajnos nem nyert. De próbálkozhatsz még :). Használj kisbetüt és ékezet nélkül add meg a választ ");
          return;
        }

        //Save slide
        var respons = site.saveIndex(slide_index);

        if (todayDate > day_5) {

          site.successAlertAutoClose("Cool", "Nagyon jól nyomod! Akkor nézzük tovább!");
          setTimeout(function () {
            location.href = "/Home/Game"
          }, 6000);

        }
        else {

          site.successAlertAutoClose("Cool!", "Sikeresen vetted a negyedik akadályt is de a következő " + slide_index + ". pálya még nem nyílt ki ..de hamarosan!");
          setTimeout(function () {
            location.href = "/Home"
          }, 6000);

        } 

        break;

      case "5":

        if ($('#name').val() != "diotoro") {
          site.warningAlert("Varázsige", "Sajnos nem nyert. De próbálkozhatsz még :). Használj kisbetüt és ékezet nélkül add meg a választ ");
          return;
        }

        //Save slide
        var respons = site.saveIndex(slide_index);

        if (todayDate > day_6) {

          site.successAlertAutoClose("Cool", "Nagyon jól nyomod! Akkor nézzük tovább!");
          setTimeout(function () {
            location.href = "/Home/Game"
          }, 6000);

        }
        else {

          site.successAlertAutoClose("Cool!", "Sikeresen vetted az ötödik akadályt is de a következő " + slide_index + ". pálya még nem nyílt ki ..de hamarosan!");
          setTimeout(function () {
            location.href = "/Home"
          }, 6000);

        } 

        break;

      case "6":

        if ($('#name').val() != "7") {
          site.warningAlert("Varázsige", "Sajnos nem nyert. De próbálkozhatsz még :). Használj kisbetüt és ékezet nélkül add meg a választ ");
          return;
        }

        //Save slide
        var respons = site.saveIndex(slide_index);

        if (todayDate > day_7) {

          site.successAlertAutoClose("Cool", "Nagyon jól nyomod! Akkor nézzük tovább!");
          setTimeout(function () {
            location.href = "/Home/Game"
          }, 6000);

        }
        else {

          site.successAlertAutoClose("Cool!", "Sikeresen vetted az hatodik akadályt is de a következő " + slide_index + ". pálya még nem nyílt ki ..de hamarosan!");
          setTimeout(function () {
            location.href = "/Home"
          }, 6000);

        } 

        break;

      case "7":

        if ($('#name').val() != "7:36") {
          site.warningAlert("Varázsige", "Sajnos nem nyert. De próbálkozhatsz még :). óra:perc legyen a formátum ");
          return;
        }

        //Save slide
        var respons = site.saveIndex(slide_index);

        site.successAlertAutoClose("Ez igen", "Akkor ninics más hátra mint....");
        setTimeout(function () {
          location.href = "/Home/Gift"
        }, 6000);

        break;
    }

  },

  saveIndex: function (id) {

    $.ajax({
      url: "/Home/SaveIndex",
      type: "post",
      dataType: 'json',
      data: {
        "index": id
      },
      complete: function (xhr, textStatus) {

        if (xhr.status == 200) {          
          return false;
        }
        else {
          location.href = "/Home/Error";
          return false;
        }
      }

    });

  },

  setHelp: function (img) {
    document.getElementById("help").src = img
  }

}

