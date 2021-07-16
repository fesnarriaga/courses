import 'package:flutter/material.dart';
import '../models/image_model.dart';

class ImageList extends StatelessWidget {
  final List<ImageModel> images;

  ImageList(this.images);

  Widget build(context) {
    return ListView.builder(
      itemCount: images.length,
      itemBuilder: (context, int index) {
        return buildImageCard(images[index]);
      },
    );
  }

  Widget buildImageCard(ImageModel imageModel) {
    return Container(
      margin: EdgeInsets.all(20.0),
      padding: EdgeInsets.all(20.0),
      decoration: BoxDecoration(
        border: Border.all(
          color: Colors.grey,
        ),
      ),
      child: Column(
        children: [
          Image.network(imageModel.url!),
          Padding(
            padding: EdgeInsets.only(top: 10.0),
            child: Text(imageModel.title!),
          ),
        ],
      ),
    );
  }
}
