
$(() => {
    console.log("Js & Jquery up and running")
    let x = 0;
    function addPersonRow(n) {
        return '<div style="font-family:KBbubblegum;"> <input class="form-control" name="people[' + n + '].FirstName" placeholder="First Name" /> <input class="form-control" name="people[' + n + '].LastName" placeholder="Last Name" /> <input class="form-control" name="people[' + n + '].Age" placeholder="Age" /> </div>'
    };

    $('.btn-warning').on('click', function () {
        console.log("Add clicked")
        let stringToAdd = addPersonRow(x);
        $('.row-cols-3').append(stringToAdd);
        x++;
    });

})