import useFetch from "../hooks/use-fetch";
import { GenericResult } from "../models/generic-result";
import { HomePage } from "../models/home-page"; 
import Spinner from "../components/Spinner";
import { useEffect } from "react";

export const Home = () => {
    const {
        response: { data, success, error: errorMsg } = {
            data: undefined,
            success: false,
            error: undefined,
        },
        error,
        //runQuery,
        loading,
    } = useFetch<GenericResult<HomePage>>({ url: "api/content/home-content" });

    useEffect(() => {
        //runQuery();
    }, []);

    return (
        <>
            <h1>hello docker</h1>
            

            <Spinner loading={loading} />
            {error && <p className="error">error ...{error?.message}</p>}
            {!loading && !success && <p className="error">error ...{errorMsg}</p>}
            {success && data && (
                <div>
                    <h1 style={{ color: "white" }}>title : {data.title}</h1>
                    <div>
                        {data.imageUrl && (
                            <img
                                title={data.title}
                                src={`${data.imageUrl}`}
                                width="auto"
                                height="200px"
                            />
                        )}
                    </div>
                </div>
            )}
        </>
    );
};

export default Home;