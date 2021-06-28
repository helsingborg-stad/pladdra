import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import Amplify from "aws-amplify";
import App from "./App";

import awsExports from "./aws-exports";

Amplify.configure(awsExports);

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById("root")
);
