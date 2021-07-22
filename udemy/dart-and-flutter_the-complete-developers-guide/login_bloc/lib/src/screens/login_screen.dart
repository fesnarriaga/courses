import 'package:flutter/material.dart';

import '../blocs/bloc.dart';
import '../blocs/provider.dart';

class LoginScreen extends StatelessWidget {
  Widget build(context) {
    // LOCAL INSTANCE
    final bloc = Provider.of(context);

    return Container(
      margin: EdgeInsets.all(20.0),
      child: Column(
        children: [
          emailField(bloc),
          passwordField(bloc),
          SizedBox(height: 20.0),
          submitButton(),
        ],
      ),
    );
  }

  Widget emailField(Bloc bloc) {
    return StreamBuilder(
      stream: bloc.email,
      builder: (context, snapshot) {
        return TextField(
          keyboardType: TextInputType.emailAddress,
          decoration: InputDecoration(
            hintText: 'you@example.com',
            labelText: 'E-mail Address',
            errorText: snapshot.hasError ? snapshot.error.toString() : null,
          ),
          onChanged: bloc.changeEmail,
        );
      },
    );
  }

  Widget passwordField(Bloc bloc) {
    return StreamBuilder(
      stream: bloc.password,
      builder: (context, snapshot) {
        return TextField(
          obscureText: true,
          decoration: InputDecoration(
            hintText: 'Password',
            labelText: 'Password',
            errorText: snapshot.hasError ? snapshot.error.toString() : null,
          ),
          onChanged: bloc.changePassword,
        );
      },
    );
  }

  Widget submitButton() {
    return ElevatedButton(
      child: Text('Login'),
      style: ElevatedButton.styleFrom(
        primary: Colors.blue,
      ),
      onPressed: () {},
    );
  }
}
