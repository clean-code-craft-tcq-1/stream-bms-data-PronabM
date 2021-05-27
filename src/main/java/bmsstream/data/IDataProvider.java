package bmsstream.data;

public interface IDataProvider {

	static final String EOF = "###";

	public String getNext();

}
