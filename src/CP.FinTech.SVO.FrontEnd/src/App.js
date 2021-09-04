import * as React from "react";
import { Admin, Resource } from "react-admin";
// import jsonServerProvider from "ra-data-json-server";
import polyglotI18nProvider from "ra-i18n-polyglot";
import russianMessages from "ra-language-russian";
import authProvider from "./authProvider";
import dataProvider from "./dataProvider";
import Layout from "./components/Layout";
import { ArendorEdit, ArendorList } from "./resources/users";
import { ContractEdit, ContractList } from "./resources/contracts";
// const dataProvider = jsonServerProvider("https://jsonplaceholder.typicode.com");
const i18NProvider = polyglotI18nProvider(() => russianMessages, "ru");

function App() {
  return (
    <Admin
      dataProvider={dataProvider}
      authProvider={authProvider}
      i18nProvider={i18NProvider}
      layout={Layout}
    >
      <Resource
        name="tenants"
        options={{ label: "Арендаторы" }}
        list={ArendorList}
        edit={ArendorEdit}
      />
      <Resource
        name="contracts"
        options={{ label: "Контракты" }}
        list={ContractList}
        edit={ContractEdit}
      />
    </Admin>
  );
}

export default App;
