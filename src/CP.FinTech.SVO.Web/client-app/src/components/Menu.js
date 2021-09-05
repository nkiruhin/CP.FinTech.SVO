import * as React from "react";
import { useSelector } from "react-redux";
import PeopleIcon from '@material-ui/icons/People';
import BookIcon from '@material-ui/icons/Book';
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
        to={`/tenant`}
        primaryText={"Арендаторы"}
        dense={dense}
        leftIcon={<PeopleIcon />}
        />
        <MenuItemLink
            to={`/contract/create`}
            primaryText={"Контракты"}
            dense={dense}
            leftIcon={<BookIcon />}
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
