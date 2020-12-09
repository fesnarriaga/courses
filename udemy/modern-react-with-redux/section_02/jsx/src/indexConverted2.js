"use strict";

var _react = _interopRequireDefault(require("react"));

var _reactDom = _interopRequireDefault(require("react-dom"));

function _interopRequireDefault(obj) {
  return obj && obj.__esModule ? obj : { default: obj };
}

const App = () => {
  return;

  /*#__PURE__*/
  _react.default.createElement(
    "div",
    null,
    /*#__PURE__*/ _react.default.createElement(
      "ul",
      null,
      /*#__PURE__*/ _react.default.createElement("li", null, "Item 1"),
      /*#__PURE__*/ _react.default.createElement("li", null, "Item 2"),
      /*#__PURE__*/ _react.default.createElement("li", null, "Item 3")
    )
  );
};

_reactDom.default.render(
  /*#__PURE__*/ _react.default.createElement(App, null),
  document.getElementById("root")
);
