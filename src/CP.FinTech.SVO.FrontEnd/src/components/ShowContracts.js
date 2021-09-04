import * as React from "react";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Grid from "@material-ui/core/Grid";
import Typography from "@material-ui/core/Typography";
import { makeStyles } from "@material-ui/core/styles";
import { useShowController, Link, useQueryWithStore } from "react-admin";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
} from "@material-ui/core";

const ShowContracts = (props) => {
  const { record } = useShowController(props);
  const classes = useStyles();
  const { loaded, data } = useQueryWithStore({
    type: "getList",
    resource: "contracts",
    payload: {
      tenant_id: record.tenant_id,
    },
  });
  if (!record) return null;
  return (
    <Card className={classes.root}>
      <CardContent>
        <Grid container spacing={2}>
          <Grid item xs={6}>
            <Typography variant="h6" gutterBottom>
              Контракты
            </Typography>
          </Grid>
          <Grid item xs={6}>
            <Typography variant="h6" gutterBottom align="right">
              Арендатор <br /> "{record.shortName}"
            </Typography>
          </Grid>
        </Grid>
        {loaded ? (
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>ID</TableCell>
                <TableCell className={classes.rightAlignedCell}>
                  ID помещения
                </TableCell>
                <TableCell className={classes.rightAlignedCell}>
                  Дата окончания
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {data.map((item) => (
                <TableRow key={item.id} component={Link} to={`/contracts/${item.id}`} >
                  <TableCell>
                   {item.id}
                  </TableCell>
                  <TableCell className={classes.rightAlignedCell}>
                    {item.rentalObjectId}
                  </TableCell>
                  <TableCell className={classes.rightAlignedCell}>
                    {new Date(item.dateEnd).toLocaleDateString()}
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        ) : (
          "Загрузка"
        )}
      </CardContent>
    </Card>
  );
};

export default ShowContracts;

const useStyles = makeStyles({
  root: { width: 600, margin: "auto" },
  spacer: { height: 20 },
  invoices: { margin: "10px 0" },
});
