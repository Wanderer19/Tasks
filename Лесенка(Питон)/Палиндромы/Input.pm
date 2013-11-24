package Input;

sub read_text{
	my $file = shift;
	local $/;
	open (my $TEXT,"$file") or return undef;
	$text = <$TEXT>;
	return $text;
}
1;