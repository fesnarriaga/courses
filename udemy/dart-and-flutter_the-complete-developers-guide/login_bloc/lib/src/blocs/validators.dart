import 'dart:async';

class Validators {
  final validateEmail = StreamTransformer<String, String>.fromHandlers(
    handleData: (email, sink) =>
        email.contains('@') ? sink.add(email) : sink.addError('Invalid email'),
  );

  final validatePassword = StreamTransformer<String, String>.fromHandlers(
    handleData: (password, sink) => password.length >= 4
        ? sink.add(password)
        : sink.addError('Invalid password'),
  );
}
