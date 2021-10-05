import { TranslationMessages } from "ra-core";
import polyglotI18nProvider from "ra-i18n-polyglot";
import swedishMessages from "@kolben/ra-language-swedish";
import englishMessages from "ra-language-english";
import customMessages from "./customMessages";

const english: TranslationMessages = {
  ...englishMessages,
  ...customMessages.en,
};
const swedish: TranslationMessages = {
  ...swedishMessages,
  ...customMessages.sv,
};

interface IMessages {
  [key: string]: TranslationMessages;
}

const messages: IMessages = {
  en: english,
  sv: swedish,
};

const i18nProvider = polyglotI18nProvider(
  (locale) => messages[locale],
  "sv" // Default locale
);

export default i18nProvider;
