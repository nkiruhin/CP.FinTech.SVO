import * as React from "react";
import {
  List,
  Edit,
  Datagrid,
  TextField,
  EditButton,
  DateInput,
  SimpleForm,
  SelectField,
  TextInput,
  ReferenceInput,
  DateField,
  SelectInput,
  NumberInput,
  required,
} from "react-admin";
import Aside from '../components/Aside';
import rentals from "../configs/rentalArray";
import { Grid, Box } from "@material-ui/core";

export const ContractList = (props) => (
  <List
    {...props}
    title={"Список Контрактов"}
    perPage={25}
    bulkActionButtons={false}
  >
    <Datagrid rowClick="edit">
      <TextField label={"ID"} source="id" />
      <SelectField
        label={"Помещение"}
        source="rentalObjectId"
        choices={rentals}
        optionValue={"id"}
        optionText={"name"}
      />
      <DateField label={"Дата окончания"} source={"dateEnd"} />

      <EditButton />
    </Datagrid>
  </List>
);
export const ContractEdit = (props) => (
  <Edit {...props} aside={<Aside />} component="div">
    <SimpleForm>
      <Box minWidth={"100%"}>
        <Grid container spacing={1}>
          <Grid item xs={12} sm={12} md={3}>
            <DateInput
              label={"Дата договора"}
              source="dateStart"
              fullWidth={true}
            />
            <DateInput
              label={"Дата окончания"}
              source="dateEnd"
              fullWidth={true}
            />
          </Grid>
          <Grid item xs={12} sm={12} md={3}>
            <SelectInput
              label={"Помещение"}
              source="rentalObjectId"
              choices={rentals}
              fullWidth={true}
            />
            <NumberInput
              label={"Ставка за кв.м"}
              source="ratePerSquareMeter"
              fullWidth={true}
            />
          </Grid>
          <Grid item xs={12} sm={12} md={3}>
            <SelectInput
              label={"Помещение"}
              source="rentalObjectId"
              choices={rentals}
              fullWidth={true}
            />
            <NumberInput
              label={"Ставка за кв.м"}
              source="ratePerSquareMeter"
              fullWidth={true}
            />
          </Grid>
          <Grid item xs={12} sm={12} md={3}>
            <TextInput fullWidth={true} label={"Платежный счет"} source="walletAddress" />
            <ReferenceInput
              label="Арендатор"
              source="tenant_id"
              reference="tenants"
              basePath={"/tenants"}
              validate={[required()]}
            >
              <SelectInput optionText="name" fullWidth={true} />
            </ReferenceInput>
          </Grid>
        </Grid>
      </Box>
    </SimpleForm>
  </Edit>
);
