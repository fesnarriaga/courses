// used babeljs.io to convert to raw react

"use strict";

var _react = _interopRequireDefault(require("react"));

var _reactDom = _interopRequireDefault(require("react-dom"));

function _interopRequireDefault(obj) {
  return obj && obj.__esModule ? obj : { default: obj };
}

const App = () => {
  return /*#__PURE__*/_react.default.createElement("div", null, "Hello world!");
};

_reactDom.default.render(
  /*#__PURE__*/_react.default.createElement(App, null), document.getElementById('root')
);
