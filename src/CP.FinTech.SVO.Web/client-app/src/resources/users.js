import * as React from "react";
import {
  List,
  Edit,
  Datagrid,
  TextField,
  EmailField,
  EditButton,
  SimpleFormIterator,
  SimpleForm,
  SelectInput,
  SelectField,
  TextInput,
  ArrayInput,
} from "react-admin";
import { Grid, Box } from "@material-ui/core";
import ShowContracts from "../components/ShowContracts";

export const ArendorList = (props) => (
  <List {...props} title={"Список Арендаторов"} perPage={25} bulkActionButtons={false}>
    <Datagrid rowClick="expand" expand={<ShowContracts />}>
      <TextField source="id" label={"ID"} />
      <TextField source="shortName" label={"Название"} />
      <TextField source="address" label={"Адрес"} />
      <TextField source="inn" label={"Инн"} />
      <SelectField
        source="orgType"
        label={"Тип организации"}
        choices={[
          {
            id: 0,
            name: "ООО",
          },
          {
            id: 1,
            name: "ИП",
          },
        ]}
      />
      <EditButton />
    </Datagrid>
  </List>
);
export const ArendorEdit = (props) => (
  <Edit {...props}>
    <SimpleForm>
      <Box minWidth={"100%"}>
        <Grid container spacing={1}>
          <Grid item xs={12} sm={12} md={3}>
            <TextInput label={"Имя"} source="name" fullWidth={true} />
            <TextInput label={"Короткое"} source="contacts" fullWidth={true} />
          </Grid>
          <Grid item xs={12} sm={12} md={3}>
            <TextInput
              label={"Имя(короткое)"}
              source="shortName"
              fullWidth={true}
            />
            <SelectInput
              label={"Тип организации"}
              fullWidth={true}
              source="orgType"
              choices={[
                {
                  id: 0,
                  name: "ООО",
                },
                {
                  id: 1,
                  name: "ИП",
                },
              ]}
            />
          </Grid>
          <Grid item xs={12} sm={12} md={3}>
            <TextInput label={"КПП"} source="kpp" fullWidth={true} />
            <TextInput label={"ОГРН"} source="ogrn" fullWidth={true} />
          </Grid>
          <Grid item xs={12} sm={12} md={3}>
            <TextInput label={"ИНН"} source="inn" fullWidth={true} />
          </Grid>
          <Grid item xs={12} sm={12} md={12}>
            <TextInput label={"Адрес"} source="address" fullWidth={true} />
            <TextInput
              label={"Адрес 2"}
              source="actualAddress"
              fullWidth={true}
            />
          </Grid>
          <ArrayInput label={"Платежный счет"} source="walletAddress" create>
            <SimpleFormIterator>
              <TextInput label={null} />
            </SimpleFormIterator>
          </ArrayInput>
        </Grid>
      </Box>
    </SimpleForm>
  </Edit>
);
