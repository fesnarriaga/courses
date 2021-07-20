class ValidationMixin {
  String? validateEmail(String? value) {
    if (value!.contains('@')) {
      return null;
    }

    return 'Invalid e-mail';
  }

  String? validatePassword(String? value) {
    if (value!.length >= 4) {
      return null;
    }

    return 'Invalid password';
  }
}
