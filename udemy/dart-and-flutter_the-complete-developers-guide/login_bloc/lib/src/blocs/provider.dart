import 'package:flutter/material.dart';

import './bloc.dart';

class Provider extends InheritedWidget {
  final bloc = Bloc();

  Provider({Key? key, required Widget child}) : super(child: child, key: key);

  bool updateShouldNotify(_) => true;

  static Bloc of(BuildContext context) =>
      context.dependOnInheritedWidgetOfExactType<Provider>()!.bloc;
}
