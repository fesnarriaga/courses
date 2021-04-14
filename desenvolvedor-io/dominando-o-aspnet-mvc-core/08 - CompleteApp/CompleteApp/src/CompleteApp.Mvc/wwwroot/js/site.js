function ajaxModal() {
    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click", function (e) {
                $("#siteModalContent").load(this.href,
                    function () {
                        $("#siteModal").modal({ keyboard: true }, "show");

                        bindForm(this);
                    });

                return false;
            });
        });

        function bindForm(dialog) {
            $('form', dialog).submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            $("#siteModal").modal("hide");
                            $("#addressTarget").load(result.url);
                        } else {
                            $("#siteModalContent").html(result);
                            bindForm(dialog);
                        }
                    }
                });

                return false;
            });
        }
    });
}

function getAddressFromPostalCode() {
    $(document).ready(function () {
        function fillAddressForm(data) {
            $("#Address_Street").val(data.logradouro);
            $("#Address_Neighborhood").val(data.bairro);
            $("#Address_City").val(data.localidade);
            $("#Address_State").val(data.uf);
        }

        function resetAddressForm() {
            var emptyString = "";

            var data = {
                logradouro: emptyString,
                bairro: emptyString,
                localidade: emptyString,
                uf: emptyString
            }

            fillAddressForm(data);
        }

        function showFormLoader() {
            var loader = "...";

            var data = {
                logradouro: loader,
                bairro: loader,
                localidade: loader,
                uf: loader
            }

            fillAddressForm(data);
        }

        $("#Address_PostalCode").blur(function () {
            var postalCode = $(this).val().replace(/\D/g, "");

            if (postalCode != "") {
                var postalCodeValidation = /^[0-9]{8}$/;

                if (postalCodeValidation.test(postalCode)) {
                    showFormLoader();

                    var url = "https://viacep.com.br/ws/" + postalCode + "/json/?callback=?";
                    $.getJSON(url,
                        function (data) {
                            if (!("erro" in data)) {
                                fillAddressForm(data);
                            } else {
                                resetAddressForm();

                                alert("Postal Code not found");
                            }
                        });
                } else {
                    resetAddressForm();

                    alert("Postal Code invalid");
                }
            } else {
                resetAddressForm();
            }
        });
    });
}
