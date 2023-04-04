import { useState } from "react";
import { Grid, GridItem } from "@chakra-ui/react";
import NavBar from "./components/NavBar";
import ResultsGrid from "./components/ResultsGrid";


function App() {

  const [search, setSearch] = useState<string>('')

  return (
    <Grid
      templateAreas={{
        base: `"nav" "main"`,
        lg: `"nav nav" "main"`,
      }}
    >
      <GridItem area="nav">
        <NavBar setWordSearch={setSearch}/>
      </GridItem>
      <GridItem area="main">
        <ResultsGrid wordSearch={search}/>
      </GridItem>
    </Grid>
  );
}

export default App;
