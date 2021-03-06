import 'package:flutter/material.dart';

import '../mixins/validation_mixin.dart';

class LoginScreen extends StatefulWidget {
  createState() {
    return LoginScreenState();
  }
}

class LoginScreenState extends State<LoginScreen> with ValidationMixin {
  final formKey = GlobalKey<FormState>();
  String email = '';
  String pass = '';

  Widget build(context) {
    return Container(
      margin: EdgeInsets.all(20.0),
      child: Form(
        key: formKey,
        child: Column(
          children: [
            buildEmailField(),
            buildPasswordField(),
            Container(margin: EdgeInsets.only(top: 25.0)),
            buildSubmitButton(),
          ],
        ),
      ),
    );
  }

  Widget buildEmailField() {
    return TextFormField(
      keyboardType: TextInputType.emailAddress,
      decoration: InputDecoration(
        labelText: 'E-mail Address',
        hintText: 'you@example.com',
      ),
      validator: validateEmail,
      onSaved: (value) {
        email = value!;
      },
    );
  }

  Widget buildPasswordField() {
    return TextFormField(
      obscureText: true,
      decoration: InputDecoration(
        labelText: 'Password',
        hintText: 'Password',
      ),
      validator: validatePassword,
      onSaved: (value) {
        pass = value!;
      },
    );
  }

  Widget buildSubmitButton() {
    return ElevatedButton(
      style: ButtonStyle(
        backgroundColor: MaterialStateProperty.all<Color>(Colors.blue),
      ),
      child: Text('Submit!'),
      onPressed: () {
        bool? isValid = formKey.currentState?.validate();
        if (isValid!) {
          formKey.currentState?.save();

          print('$email - $pass');
        }
      },
    );
  }
}
