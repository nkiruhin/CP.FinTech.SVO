import * as React from "react";
import {
  NumberField,
  TextField,
  DateField,
  useTranslate,
  useGetList,
  useLocale,
} from "react-admin";
import OrderIcon from "@material-ui/icons/AttachMoney";
import {
  Typography,
  Grid,
  Stepper,
  Step,
  StepLabel,
  StepContent,
} from "@material-ui/core";
import { Link as RouterLink } from "react-router-dom";
import AccessTimeIcon from "@material-ui/icons/AccessTime";
import { makeStyles } from "@material-ui/core/styles";

const useAsideStyles = makeStyles((theme) => ({
  root: {
    width: 400,
    [theme.breakpoints.down("md")]: {
      display: "none",
    },
  },
}));

const Aside = ({ record, basePath }) => {
  const classes = useAsideStyles();
  return (
    <div className={classes.root}>
      {record && <EventList record={record} basePath={basePath} />}
    </div>
  );
};

const useEventStyles = makeStyles({
  stepper: {
    background: "none",
    border: "none",
    marginLeft: "0.3em",
  },
});

const EventList = ({ record, basePath }) => {
  const classes = useEventStyles();
  const locale = useLocale();

  const events = [
    {
      id: 1,
      date: 1630753052000,
      source: "asdasddasd",
      destination: "asdasdasd",
      amount: 12312,
      contract_id: 1,
    },
  ];

  return (
    <>
      <Stepper orientation="vertical" classes={{ root: classes.stepper }}>
        {events.map((event) => (
          <Step key={event.id} expanded active completed>
            <StepLabel
              StepIconComponent={() => {
                const Component = OrderIcon;
                return (
                  <Component
                    fontSize="small"
                    color="disabled"
                    style={{ paddingLeft: 3 }}
                  />
                );
              }}
            >
              {new Date(event.date).toLocaleString(locale, {
                weekday: "long",
                year: "numeric",
                month: "short",
                day: "numeric",
                hour: "numeric",
                minute: "numeric",
              })}
            </StepLabel>
            <StepContent>
              <Order
                record={event}
                key={`event_${event.id}`}
                basePath={basePath}
              />
            </StepContent>
          </Step>
        ))}
      </Stepper>
    </>
  );
};

const Order = ({ record, basePath }) => {
  return record ? (
    <>
      <Typography variant="body2" color="textSecondary">
        <NumberField
          source="amount"
          options={{
            style: "currency",
            currency: "RUB",
          }}
          record={record}
          basePath={basePath}
        />
        <br />
        <Grid container>
          <Grid item xs={6}>
            <Typography variant="body2">Счет списания</Typography>
            <TextField source="source" record={record} basePath={basePath} />
          </Grid>
          <Grid item xs={6}>
            <Typography variant="body2">Счет зачисления</Typography>
            <TextField
              source="destination"
              record={record}
              basePath={basePath}
            />
          </Grid>
        </Grid>
      </Typography>
    </>
  ) : null;
};

export default Aside;
