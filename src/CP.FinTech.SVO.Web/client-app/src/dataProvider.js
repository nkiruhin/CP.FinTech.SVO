import { fetchUtils } from "react-admin";
import { stringify } from "query-string";

const apiUrl = "/api";
const httpClient = fetchUtils.fetchJson;
const jsonArendors = [
  {
    name: "ООО Переработка остатков крупного рогатого скота",
    shortName: " ООО Рога и копыт",
    address: "135040, Челябинская область, город Чехов, спуск Косиора, 9",
    actualAddress: "217221, Тульская область, город Серпухов, наб. Ленина, 69",
    contacts: "+7(555) 562-45-45 rogov@net.biz",
    inn: "8452150736",
    kpp: "309445806",
    ogrn: "9113863442937",
    orgType: 0,
    walletAddress: ["asdasdasd", "asdasdasdasd32"],
    id: 1,
  },
  {
    name: "ООО Переработка остатков2",
    shortName: " ООО Рога и копыт",
    address: "135040, Челябинская область, город Чехов, спуск Косиора, 9",
    actualAddress: "217221, Тульская область, город Серпухов, наб. Ленина, 69",
    contacts: "+7(555) 562-45-45 rogov@net.biz",
    inn: "8452150736",
    kpp: "309445806",
    ogrn: "9113863442937",
    orgType: 1,
    walletAddress: ["asdasdasd", "asdasdasdasd32"],
    id: 2,
  },
];
const jsonContracts = [
  {
    dateStart: 1630753052000,
    dateEnd: 1630755252000,
    rentalObjectId: 2,
    ratePerSquareMeter: "121",
    walletAddress: "asdasd",
    tenant_id: 1,
    id: 1,
  },
  {
    dateStart: 1630753052000,
    dateEnd: 1630755252000,
    rentalObjectId: 1,
    ratePerSquareMeter: "1212",
    walletAddress: "asdasd",
    tenant_id: 2,
    id: 2,
  },
];
export const apiProvider = {
  getList: async (resource, params) => {
    const url = `${apiUrl}/${resource}`;
    let response = await httpClient(url);
    let data = JSON.parse(response.body);
    //let response;
    //if (resource == "tenants") response = jsonArendors;
    //if (resource == "contracts") response = jsonContracts;
    return { data: data, total: 10 };
  },
  getMany: async (resource, params) => {
      const url = `${apiUrl}/${resource}`;
      let response = await httpClient(url);
      let data = JSON.parse(response.body);
      return { data: data };
  },
  getOne: async (resource, params) => {
    let response = await httpClient(`${apiUrl}/${resource}/${params.id}`);
    let data = JSON.parse(response.body);
      return { data: data };
  },
  create: async (resource, params) => {
     let response = await httpClient(`${apiUrl}/${resource}`, {
       method: "POST",
       body: JSON.stringify(params.data),
     });
    return { data: { ...params.data, id: 1 } };
  },
  update: async (resource, params) => {
     let response = await httpClient(`${apiUrl}/${resource}/${params.id}`, {
       method: "PUT",
       body: JSON.stringify(params.data),
     });
    return { data: { id: 3 } };
  },
  delete: async (resource, params) => {
    // let response = await httpClient(`${apiUrl}/${resource}/${params.id}`, {
    //   method: "DELETE",
    // });
    return { data: {} };
  },
  deleteMany: async (resource, params) => {
    // const query = {
    //   filter: JSON.stringify({ id: params.ids }),
    // };
    // let response = await httpClient(
    //   `${apiUrl}/${resource}/${stringify(query)}`,
    //   {
    //     method: "DELETE",
    //   }
    // );
    return { data: [{}] };
  },
};

export default apiProvider;
