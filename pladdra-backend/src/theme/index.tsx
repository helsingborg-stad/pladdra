import { createTheme } from "@material-ui/core";
import { defaultTheme } from "react-admin";
import plaette from "./palette";

const theme = {
  ...defaultTheme,
  ...{
    palette: {
      primary: {
        light: "#EB5757",
        main: plaette.primary.red[1],
        dark: plaette.primary.red[2],
        contrastText: plaette.neutrals[8],
      },
      secondary: {
        light: "#AE0B05",
        main: "#AE0B05",
        dark: "#AE0B05",
        contrastText: plaette.neutrals[8],
      },
    },
    typography: {
      // Use the system font instead of the default Roboto font.
      // fontFamily: ['-apple-system', 'BlinkMacSystemFont', '"Segoe UI"', 'Arial', 'sans-serif'].join(','),
    },
    overrides: {
      MuiButton: {
        // override the styles of all instances of this component
        root: {
          // Name of the rule
          color: "white", // Some CSS
        },
      },
    },
  },
};

// export const theme = merge({}, defaultTheme, {
//   palette: {
//     primary: {
//       light: "#EB5757",
//       main: plaette.primary.red[1],
//       dark: plaette.primary.red[2],
//       contrastText: plaette.neutrals[8],
//     },
//     secondary: {
//       light: "#AE0B05",
//       main: "#AE0B05",
//       dark: "#AE0B05",
//       contrastText: plaette.neutrals[8],
//     },
//   },
//   typography: {
//     // Use the system font instead of the default Roboto font.
//     // fontFamily: ['-apple-system', 'BlinkMacSystemFont', '"Segoe UI"', 'Arial', 'sans-serif'].join(','),
//   },
//   overrides: {
//     MuiButton: {
//       // override the styles of all instances of this component
//       root: {
//         // Name of the rule
//         color: "white", // Some CSS
//       },
//     },
//   },
// });

export default createTheme(theme);
