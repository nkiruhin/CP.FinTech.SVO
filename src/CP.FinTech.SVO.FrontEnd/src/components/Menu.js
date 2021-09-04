import * as React from "react";
import { useSelector } from "react-redux";
import SettingsIcon from '@material-ui/icons/Settings';
import { makeStyles } from '@material-ui/core/styles';
import {
  MenuItemLink,
} from "react-admin";



const Menu = ({ dense = false }) => {
  useSelector((state) => state.theme); // force rerender on theme change
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <MenuItemLink
        to={`/tenants`}
        primaryText={"Арендаторы"}
        dense={dense}
        leftIcon={<SettingsIcon />}
      />
    </div>
  );
};

const useStyles = makeStyles(theme => ({
    root: {
        marginTop: theme.spacing(1),
    },
}));

export default Menu;
