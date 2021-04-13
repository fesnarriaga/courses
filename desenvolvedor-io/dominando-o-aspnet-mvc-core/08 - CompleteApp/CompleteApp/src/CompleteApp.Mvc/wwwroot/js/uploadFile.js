$("#Image").change(function () {
    if (this.files[0]) {
        $("#imageUrl").text(this.files[0].name);
        $("#imageUrl")[0].style.display = "block";
    }
});

if (!window.location.pathname.includes("/Edit")) {
    $("#Image").attr("data-val", "true");
    $("#Image").attr("data-val-required", "Image is required");
}
