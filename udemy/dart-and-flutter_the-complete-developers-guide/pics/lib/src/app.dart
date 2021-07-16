import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' show get;
// import 'package:http/http.dart' as http;

import './widgets/image_list.dart';
import './models/image_model.dart';

class App extends StatefulWidget {
  createState() {
    return AppState();
  }
}

class AppState extends State<App> {
  int counter = 0;
  List<ImageModel> imageList = [];

  void fetchImage() async {
    counter++;
    print('counter: $counter');

    var baseUrl = 'jsonplaceholder.typicode.com';
    var url = Uri.https(baseUrl, '/photos/$counter');

    final response = await get(url);
    final imageModel = ImageModel.fromJson(json.decode(response.body));

    setState(() {
      imageList.add(imageModel);
    });
  }

  Widget build(context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: Text('Let\'s see some images!'),
        ),
        floatingActionButton: FloatingActionButton(
          child: Icon(Icons.add),
          onPressed: fetchImage,
        ),
        body: ImageList(imageList),
      ),
    );
  }
}
