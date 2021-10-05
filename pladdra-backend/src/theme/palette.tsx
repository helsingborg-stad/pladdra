/**
 * Primary colors appear the most in the UI, and are the ones that determine the overall
 * "look" of the application. These are used for things like primary actions, links, navigation items,
 * icons, accent borders, or text that we empahsize.
 */

const primary = {
  blue: ["#003359", "#005C86", "#1C73A6", "#4989B6"],
  green: ["#205400", "#50811B", "#6F9725", "#80B14A"],
  red: ["#770000", "#AE0B05", "#B23700", "#E84C31", "#AE0A04"],
  purple: ["#4B0034", "#7B075E", "#9E166A", "#AD428B"],
  neutral: ["#000000", "#3D3D3D", "#565656", "#707070"],
};

/**
 * Complemetary colors should be used fairly conservativley thorughout our UI to avoid overpowering our
 * primary colors. Use them when you need an element to stand out, or reinforce things like error
 * states or positive trends.
 */

const complementary = {
  blue: ["#C2CED7", "#DBE4E9", "#E4EBF0", "#EEF3F6"],
  green: ["#C9D6C2", "#E1E9DB", "#EAF0E4", "#F2F6EE"],
  red: ["#DEC2C2", "#F0DBD9", "#F5E4E3", "#FAEEEC"],
  purple: ["#D4C2CE", "#E8DAE4", "#EFE4EB", "#F6EDF3"],
  neutral: ["#C5C5C5", "#D5D5D5", "#F5F5F5", "#FFFFFF"],
};

/**
 * Neutral colors are used the most and makes up the majority of the UI.
 * They are used for most of the texts, backgrounds, and borders, as well as for things like
 * secondary buttons and links
 */
const neutrals = [
  "#000000",
  "#3D3D3D",
  "#565656",
  "#707070",
  "#A3A3A3",
  "#F5F5F5",
  "#FCFCFC",
  "#FFFFFF",
];

/**
 * The color palette that includes all our different color categories
 * (primary, neutrals, supporting etc)
 */

export const colorPalette = {
  primary,
  complementary,
  neutrals,
};

export default colorPalette;
