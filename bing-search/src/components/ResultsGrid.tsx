import { useEffect, useState, FunctionComponent } from "react";
import apiClient from "../services/api-client";
import {
  Spinner,
  Tab,
  TabIndicator,
  TabList,
  TabPanel,
  TabPanels,
  Tabs,
} from "@chakra-ui/react";
import WebPageCard from "./WebPageCard";
import ImageCard from "./ImageCard";
import NewCard from "./NewCard";
import VideoCard from "./VideoCard";

interface FetchResultsResponse {
  webPages: WebPages;
  images: Images;
  news: News;
  videos: Videos;
}

interface SearchProps {
  wordSearch: string;
}
const styles = {
  classFlex: {
    display: "grid",
    gridTemplateColumns: "repeat(4, 1fr)",
    gridTemplateRows: "repeat(3, 1fr)",
    gridColumnGap: "0px",
    gridRowGap: "0px",
  },
};

const ResultsGrid: FunctionComponent<SearchProps> = (props: SearchProps) => {
  const [searchResults, setSearchResults] = useState<FetchResultsResponse>();
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(false);

  useEffect(() => {
    if (props.wordSearch !== "") {
      setLoading(true);
      apiClient
        .get<FetchResultsResponse>(
          `/search?count=10&mkt=en-US&q=${props.wordSearch}`
        )
        .then((res) => {
          setSearchResults(res.data);
          setLoading(false);
        })
        .catch((err) => {
          setError(err.message);
          setLoading(false);
        });
    }
  }, [props.wordSearch]);

  return (
    <Tabs position="relative" variant="unstyled">
      <TabList>
        <Tab>Web Pages</Tab>
        <Tab>Images</Tab>
        <Tab>News</Tab>
        <Tab>Videos</Tab>
      </TabList>
      <TabIndicator mt="-1.5px" height="2px" bg="blue.500" borderRadius="1px" />
      <TabPanels>
        <TabPanel>
          <div color="white" style={styles.classFlex}>
            {searchResults?.webPages?.value ? searchResults?.webPages?.value?.map((item, index) => (
              <WebPageCard key={index} pageData={item} />
            )): props.wordSearch && <p>No results found</p>}
          </div>
        </TabPanel>
        <TabPanel className="">
          <div color="white" style={styles.classFlex}>
            {searchResults?.images?.value ? searchResults?.images?.value?.map((item, index) => (
              <ImageCard key={index} pageData={item} />
            )): props.wordSearch && <p>No results found</p>}
          </div>
        </TabPanel>
        <TabPanel>
          <div color="white" style={styles.classFlex}>
            {searchResults?.news?.value ? searchResults?.news?.value?.map((item, index) => (
              <NewCard key={index} pageData={item} />
            )): props.wordSearch && <p>No results found</p>}
          </div>
        </TabPanel>
        <TabPanel>
          <div color="white" style={styles.classFlex}>
            {searchResults?.videos?.value ?searchResults?.videos?.value?.map((item, index) => (
              <VideoCard key={index} pageData={item} />
            )): props.wordSearch && <p>No results found</p>}
          </div>
        </TabPanel>
      </TabPanels>
      {loading ? <Spinner
            thickness="4px"
            speed="0.65s"
            emptyColor="gray.200"
            color="blue.500"
            size="xl"
          /> : null}
    </Tabs>
  );
};

export default ResultsGrid;
