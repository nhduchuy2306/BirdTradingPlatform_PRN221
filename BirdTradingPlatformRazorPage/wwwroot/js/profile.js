function SwitchForm(value) {
    var x = document.getElementById("frm-account");
    var y = document.getElementById("frm-profile");
    var z = document.getElementById("frm-order");
    var x1 = document.getElementById("nav-account");
    var y1 = document.getElementById("nav-profile");
    var z1 = document.getElementById("nav-order");


    switch (value) {
        case 'account':
            x.style.display = 'block';
            y.style.display = 'none';
            z.style.display = 'none';
            x1.classList.add("active");
            y1.classList.remove("active");
            z1.classList.remove("active");
            break;
        case 'profile':
            x.style.display = 'none';
            y.style.display = 'block';
            z.style.display = 'none';
            x1.classList.remove("active");
            y1.classList.add("active");
            z1.classList.remove("active");
            break;
        case 'order':
            x.style.display = 'none';
            y.style.display = 'none';
            z.style.display = 'block';
            x1.classList.remove("active");
            y1.classList.remove("active");
            z1.classList.add("active");
            break;
        default:
            x.style.display = 'block';
            y.style.display = 'none';
            break;
    }
}
